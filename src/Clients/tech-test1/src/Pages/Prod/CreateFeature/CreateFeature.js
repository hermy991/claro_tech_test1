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

export class PageProdCreateFeature extends React.Component {
  constructor(props) {
    super(props);
    
    this.state = { tabs, form: formNew, features: [] };
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

  handlerSave = async () => {
    let j = await prod.saveFeature(this.state.form);
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
    this.setState({ form: formNew});
  }

  handlerSelectFeature(form){
    this.setState({ form });
    this.handlerSelectedTab({title: this.state.tabs[1].title});
  }

  render() {
    return (<div>
              <div className="box">
                <Tabs handlerClick={this.handlerSelectedTab}>
                  { this.state.tabs.map((x, i) => 
                    i === 0 
                      ? <Tab key={i.toString()} {...x}>{this.table()}</Tab> 
                      : <Tab {...x}><Form form={this.state.form} handlerChange={this.handlerChange} handlerSave={this.handlerSave} handlerNew={this.handlerNew} /></Tab>
                  )}

                </Tabs>
              </div>
            </div>)
  }
}