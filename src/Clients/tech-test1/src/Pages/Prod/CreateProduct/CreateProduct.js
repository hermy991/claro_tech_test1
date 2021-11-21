import React from "react";
import { Tabs } from "../../../Components/Tabs";
import { Tab} from "../../../Components/Tab";
import * as prod from "../../../Services/Prod"
import {Form} from "./Form"

const tabs = [
  { title:"Listado de Productos", icon: "fa fa-list", active: true },
  { title:"Registro de Producto", icon: "fa fa-pencil-square-o", active: false },
]

const formNew = {
  Merchandise_ID: undefined,
  MerchandiseCode: "",
  ProductCode: "",
  ProductDisplay: "",
  ProductShort: "",
  Tax: 0,
  TotalPrice: 0,
  Active: true
}

export class PageProdCreateProduct extends React.Component {
  constructor(props) {
    super(props);
    
    this.state = { tabs, form: formNew, merchandises: [], products: [], features: [], featureDetails: [] };
  }

  componentDidMount = async () => {
    await this.init();
  }

  init = async () => {
    {
      let j = await prod.fgetProducts();
      console.log("data", j.data)
      if(j.error)
        console.log("j.error", j.error);
      else 
        this.setState({ products: j.data});
    }
    {
      let j = await prod.getMerchandises({ Active: true});
      if(j.error)
        console.log("j.error", j.error);
      else 
        this.setState({ merchandises: j.data});
    }
  }

  findFeatures = async () => {
    let j = await prod.getFeatures();
    if(j.error){
      console.log("j.error", j.error)
    }
    else {
      this.setState({ features: j.data});
    }
  }

  findProductFeatures = async ({ Merchandise_ID, Product_ID}) => {
    let j = await prod.fgetProductFeatures(
      { Merchandise_ID: Merchandise_ID || null, Product_ID: Product_ID || null, Active: true }
      );
    if(j.error){
      console.log("j.error", j.error)
    }
    else {
      let features = j.data.map(x => x.Feature_ID);
      let d = await prod.fgetFeatureDetails({ Feature_ID: features });
      this.setState({ features: j.data, featureDetails: d.data });
    }
  }

  handlerSelectedTab = ({ title, e }) => {
    // console.log("title", title, "e", e);
    this.setState(function(state/*, props*/) {
      state.tabs.forEach(x => x.active = false);
      state.tabs.filter(x => x.title === title).forEach(x => x.active = true);
      return {
        tabs: state.tabs
      };
    });
  }

  table = () => {
    return (
    <div className="table-container">
      <table className="table is-bordered is-striped is-narrow is-hoverable is-fullwidth">
        <thead>
          <tr className="has-background-info">
            <th className="has-text-info-light"><abbr title="Código Producto">Código Producto</abbr></th>
            <th className="has-text-info-light"><abbr title="Nombre Producto">Nombre Producto</abbr></th>
            <th className="has-text-info-light"><abbr title="Impuesto">Impuesto</abbr></th>
            <th className="has-text-info-light"><abbr title="Precio Final">Precio Final</abbr></th>
            <th className="has-text-info-light"><abbr title="Estatus">Estatus</abbr></th>
          </tr>
        </thead>
        <tbody className="is-clickable"> {
          this.state.products.map(x => 
            <tr onClick={() => this.handlerSelectProduct(x)}>
              <th>{x.ProductCode.toString().padStart(4, "0")}</th>
              <td>{x.ProductDisplay}</td>
              <td>{x.Tax}</td>
              <td>{x.TotalPrice}</td>
              <td>{x.Active ? "Habilitado" : "Deshabilitado"}</td>
            </tr>
          )}
        </tbody>
      </table>
    </div>
    );
  }

  handlerChange = async (e) => {
    const target = e.target;
    let value = target.type === 'checkbox' ? target.checked : target.value;
    value = value === "true" ? true : value === "false" ? false : value;
    const name = target.name;
    if(name === "Merchandise_ID"){
      await this.findProductFeatures({ Product_ID: this.state.form.Product_ID || 0, [name]: Number(value || 0) });
    }
    this.setState({ form: { ...this.state.form, [name]: value } });
  }

  handlerSelectChange = (index, o, e) => {
    const target = e.target;
    let features = this.state.features;
    features[index] = { ...features[index], FeatureDetail_ID: target.value };
    this.setState({ features });
  }

  handlerSave = async () => {
    let tform = JSON.parse(JSON.stringify(this.state.form));
    tform.Merchandise_ID = Number(tform.Merchandise_ID);
    tform.ProductFeatures = JSON.parse(JSON.stringify(
      this.state.features
      .filter(x => Number(x.FeatureDetail_ID))
      .map(x => ({ 
        Merchandise_ID: x.Merchandise_ID,
        Feature_ID: x.Feature_ID, 
        FeatureDetail_ID: Number(x.FeatureDetail_ID),
        Active: true 
      }))));
    let j = await prod.saveProduct(tform);
    if(j.error){
      console.log("j.error", j.error);
    }
    else {
      await this.init();
      this.handlerSelectedTab({title: this.state.tabs[0].title});
      this.handlerNew();
    }
  }

  handlerNew = () => {
    let features = this.state.features;
    features.forEach(x => x.Selected = false);
    this.setState({ form: formNew, features });
  }

  handlerSelectProduct = async (form) => {
    this.setState({ form });
    this.handlerSelectedTab({title: this.state.tabs[1].title});
    await this.findProductFeatures(form);
  }

  render() {
    return (
      <div>
        <div className="box">
          <Tabs handlerClick={this.handlerSelectedTab}>
            { this.state.tabs.map((x, i) => 
              i === 0 
                ? <Tab key={i.toString()} {...x}>{this.table()}</Tab> 
                : <Tab {...x}>
    {/* this.state = { tabs, form: formNew, merchandises: [], products: [], features: [] }; */}
                    <Form form={this.state.form} merchandises={this.state.merchandises} 
                          handlerChange={this.handlerChange} handlerSelectChange={this.handlerSelectChange}
                          details={this.state.features} featureDetails={this.state.featureDetails}
                          handlerSave={this.handlerSave} handlerNew={this.handlerNew}/>
                  </Tab>
            )}

          </Tabs>
        </div>
      </div>
      );
  }
}