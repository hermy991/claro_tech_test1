import React  from "react";
import { Tabs } from "../../../Components/Tabs";
import { Tab} from "../../../Components/Tab";
import * as prod from "../../../Services/Prod"
import {Form} from "./Form"

const tabs = [
  { title:"Listado de Caracteristicas", icon: "fa fa-list", active: true },
  { title:"Registro de Caracteristica", icon: "fa fa-pencil-square-o", active: false },
]

export class PageProdCreateFeature extends React.Component {
  constructor(props) {
    super(props);
    
    this.state = { tabs, features: [] };
  }

  componentDidMount = async () => {
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
            <th className="has-text-info-light"><abbr title="Código Caracteristica">Código Caracteristica</abbr></th>
            <th className="has-text-info-light"><abbr title="Nombre Caracteristica">Nombre Caracteristica</abbr></th>
          </tr>
        </thead>
        <tbody className="is-clickable"> {
          this.state.features.map(x => 
            <tr><th>{x.FeatureCode.toString().padStart(4, "0")}</th>
            <td>{x.FeatureDisplay}</td></tr>
          )}
        </tbody>
      </table>
    </div>
    );
  }

  render() {
    return (<div>
              <div className="box">
                <Tabs handlerClick={this.handlerSelectedTab}>
                  { this.state.tabs.map((x, i) => 
                    i === 0 
                      ? <Tab key={i.toString()} {...x}>{this.table()}</Tab> 
                      : <Tab {...x}><Form /></Tab>
                  )}

                </Tabs>
              </div>
            </div>)
  }
}