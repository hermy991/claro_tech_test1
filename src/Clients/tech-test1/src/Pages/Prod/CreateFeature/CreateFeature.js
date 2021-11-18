import React  from "react";
import { Tabs } from "../../../Components/Tabs";
import { Tab} from "../../../Components/Tab";
import * as prod from "../../../Services/Prod"

const tabs = [
  { title:"Listado de Caracteristicas", icon: "fa fa-list", active: false },
  { title:"Registro de Caracteristica", icon: "fa fa-pencil-square-o", active: true },
]

export class PageProdCreateFeature extends React.Component {
  constructor(props) {
    super(props);
    
    this.state = { tabs };
  }

  componentDidMount = async () => {
    let data = await prod.getFeactures();
    console.log("data", data);
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
        <tbody>
          <tr className="is-clickable">
            <th>0001</th>
            <td>Color</td>
          </tr>
        </tbody>
      </table>
    </div>
    );
  }

  render() {
    return (<div>
              <div className="box">
                {/* <div className="tabs">
                  <ul>
                    <TabHeader title="Listado de Caracteristicas" icon="fa fa-list" active={true} />
                    <TabHeader title="Registro de Caracteristica" icon="fa fa-pencil-square-o" />
                  </ul>
                </div>
                {this.table()} */}
                <Tabs handlerClick={this.handlerSelectedTab}>
                  { this.state.tabs.map((x, i) => i === 0 ? <Tab key={i.toString()} {...x}>{this.table()}</Tab> : <Tab {...x}><p>Registro de Caracteristica</p></Tab>) }

                </Tabs>
              </div>
            </div>)
  }
}