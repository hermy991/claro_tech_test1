import React  from "react";
import { Tabs } from "../../../Components/Tabs";
import { Tab} from "../../../Components/Tab";
import * as prod from "../../../Services/Prod"
import {Form} from "./Form"

const tabs = [
  { title:"Listado de Características", icon: "fa fa-list", active: true },
  { title:"Registro de Característica", icon: "fa fa-pencil-square-o", active: false },
]

const formNew = {
  FeatureCode: "New",
  FeatureDisplay: "",
  Active: true
}

const formDetailNew = {
  FeatureDetailDisplay: "",
  Active: true
}

export class PageProdCreateFeature extends React.Component {
  constructor(props) {
    super(props);
    
    this.state = { tabs, form: formNew, detailIndex: -1, formDetail: formDetailNew, features: [], featureDetails: [] };
  }

  componentDidMount = async () => {
    await this.init();
  }

  init = async () => {
    let j = await prod.getFeatures();
    if(j.error){
      console.log("j.error", j.error)
    }
    else {
      this.setState({ features: j.data});
    }
  }

  findFeatureDetails = async (Feature_ID) => {
    let j = await prod.getFeatureDetails({ Feature_ID, Active: true });
    if(j.error){
      console.log("j.error", j.error)
    }
    else {
      this.setState({ featureDetails: j.data});
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
            <th className="has-text-info-light"><abbr title="Código Característica">Código Característica</abbr></th>
            <th className="has-text-info-light"><abbr title="Nombre Característica">Nombre Característica</abbr></th>
            <th className="has-text-info-light"><abbr title="Estatus">Estatus</abbr></th>
          </tr>
        </thead>
        <tbody className="is-clickable"> {
          this.state.features.map(x => 
            <tr onClick={() => this.handlerSelectFeature(x)}>
              <th>{x.FeatureCode.toString().padStart(4, "0")}</th>
              <td>{x.FeatureDisplay}</td>
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

  handlerDetailChange = (e) => {
    const target = e.target;
    let value = target.type === 'checkbox' ? target.checked : target.value;
    value = value === "true" ? true : value === "false" ? false : value;
    const name = target.name;
    this.setState({ formDetail: { ...this.state.formDetail, [name]: value } });
  }

  handlerSelectFeature = async (form) => {
    this.setState({ form });
    this.handlerSelectedTab({title: this.state.tabs[1].title});
    await this.findFeatureDetails(form.Feature_ID);
  }

  handlerFeatureDetailButtons = (operation /* +,-,/ */, index, featureDetail) => {
    if(!featureDetail.FeatureDetailDisplay) {
      return;
    }
    let { featureDetails } = this.state; 
    featureDetails.forEach((x, i) => {
      if(x.FeatureDetailDisplay.trim().toUpperCase() === featureDetail.FeatureDetailDisplay.trim().toUpperCase())
        index = i;
    })
    if(operation === "+" && index >= 0 && featureDetails.length > index){
      featureDetails[index] = { ...featureDetails[index], ...featureDetail }
      this.setState({ featureDetails: featureDetails, detailIndex: -1, formDetail: formDetailNew })
    }
    else if(operation === "+" && index === -1){
      featureDetails.push(featureDetail);
      this.setState({ featureDetails: featureDetails, detailIndex: -1, formDetail: formDetailNew })
    }
    else if(operation === "-" && index >= 0 && featureDetails.length > index){
      console.log({operation /* +,-,/ */, index, featureDetail})
      delete featureDetails[index];
      this.setState({ featureDetails: featureDetails, detailIndex: -1, formDetail: formDetailNew })
    }
    else if(operation === "/"){
      this.setState({ detailIndex: -1, formDetail: formDetailNew })
    }
  }

  handlerSelectFeatureDetail = (selectedIndex) => {
    this.setState({ detailIndex: selectedIndex, formDetail: this.state.featureDetails[selectedIndex] })
  }

  handlerSave = async () => {
    let tform = JSON.parse(JSON.stringify(this.state.form));
    tform.FeatureDetails = JSON.parse(JSON.stringify(this.state.featureDetails.filter(x => x)));
    let j = await prod.saveFeature(tform);
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
    this.setState({ form: formNew, detailIndex: -1, formDetail: formDetailNew, featureDestails: []});
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
                                      detailIndex={this.state.detailIndex} formDetail={this.state.formDetail} details={this.state.featureDetails }
                                      handlerDetailChange={this.handlerDetailChange} handlerSelectDetail={this.handlerSelectFeatureDetail} handlerDetailButtons={this.handlerFeatureDetailButtons} 
                                      handlerSave={this.handlerSave} handlerNew={this.handlerNew} />
                        </Tab>
                  )}

                </Tabs>
              </div>
            </div>)
  }
}