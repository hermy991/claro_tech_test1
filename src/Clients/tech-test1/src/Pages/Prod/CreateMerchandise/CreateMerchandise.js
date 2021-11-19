import React  from "react";
import { Tabs } from "../../../Components/Tabs";
import { Tab} from "../../../Components/Tab";
import * as prod from "../../../Services/Prod"
import {Form} from "./Form"

const tabs = [
  { title:"Listado de Mercancías", icon: "fa fa-list", active: true },
  { title:"Registro de Mercancía", icon: "fa fa-pencil-square-o", active: false },
]

const formNew = {
  MerchandiseCode: "",
  MerchandiseDisplay: "",
  Active: true
}

export class PageProdCreateMerchandise extends React.Component {
  constructor(props) {
    super(props);
    
    this.state = { tabs, form: formNew, merchandises: [], features: [] };
  }

  componentDidMount = async () => {
    await this.init();
    await this.findFeatures();
  }

  init = async () => {
    let j = await prod.getMerchandises();
    if(j.error){
      console.log("j.error", j.error)
    }
    else {
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

  findMerchandiseFeatures = async (Merchandise_ID) => {
    let j = await prod.getMerchandiseFeatures({ Merchandise_ID, Active: true });
    if(j.error){
      console.log("j.error", j.error)
    }
    else {
      let features = this.state.features;
      let selecteds = j.data.map(x => x.Feature_ID);
      features.forEach(x => x.Selected = selecteds.includes(x.Feature_ID));
      this.setState({ features });
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
            <th className="has-text-info-light"><abbr title="Código Mercancía">Código Mercancía</abbr></th>
            <th className="has-text-info-light"><abbr title="Nombre Mercancía">Nombre Mercancía</abbr></th>
            <th className="has-text-info-light"><abbr title="Estatus">Estatus</abbr></th>
          </tr>
        </thead>
        <tbody className="is-clickable"> {
          this.state.merchandises.map(x => 
            <tr onClick={() => this.handlerSelectMerchandise(x)}>
              <th>{x.MerchandiseCode.toString().padStart(4, "0")}</th>
              <td>{x.MerchandiseDisplay}</td>
              <td>{x.Active ? "Habilitado" : "Deshabilitado"}</td>
            </tr>
          )}
        </tbody>
      </table>
    </div>
    );
  }

  handlerChange = (e) => {
    const target = e.target;
    let value = target.type === 'checkbox' ? target.checked : target.value;
    value = value === "true" ? true : value === "false" ? false : value;
    const name = target.name;
    this.setState({ form: { ...this.state.form, [name]: value } });
  }

  handlerCheckChange = (index, o) => {
    let features = this.state.features;
    features[index] = { ...features[index], Selected: !o.Selected };
    this.setState({ features });
  }

  handlerSave = async () => {
    let tform = JSON.parse(JSON.stringify(this.state.form));
    tform.FeatureSelections = JSON.parse(JSON.stringify(this.state.features.filter(x => x.Selected).map(x => x.Feature_ID)));
    let j = await prod.saveMerchandise(tform);
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

  handlerSelectMerchandise = async (form) => {
    this.setState({ form });
    this.handlerSelectedTab({title: this.state.tabs[1].title});
    await this.findMerchandiseFeatures(form.Merchandise_ID);
  }

  render() {
    return (<div>
              <div className="box">
                <Tabs handlerClick={this.handlerSelectedTab}>
                  { this.state.tabs.map((x, i) => 
                    i === 0 
                      ? <Tab key={i.toString()} {...x}>{this.table()}</Tab> 
                      : <Tab {...x}>
                          <Form form={this.state.form} handlerChange={this.handlerChange} 
                                      details={this.state.features } handlerCheckChange={this.handlerCheckChange}
                                      handlerSave={this.handlerSave} handlerNew={this.handlerNew} />
                        </Tab>
                  )}

                </Tabs>
              </div>
            </div>)
  }
}