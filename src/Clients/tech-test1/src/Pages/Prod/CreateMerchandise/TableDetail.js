import React from "react";

export function TableDetail(props) {
  return (
    <div className="table-container">
      <table className="table is-bordered is-striped is-narrow is-hoverable is-fullwidth">
        <thead>
          <tr className="has-background-info">
            <th className="has-text-info-light"><abbr title="Código Característica">Código Característica</abbr></th>
            <th className="has-text-info-light"><abbr title="Nombre Característica">Nombre Característica</abbr></th>
            <th className="has-text-info-light"><abbr title="Nombre Característica">Selección</abbr></th>
          </tr>
        </thead>
        <tbody > {
          (props.details || []).map((x , i) => 
            <tr >
              <th>{x.Feature_ID}</th>
              <td>{x.FeatureDisplay}</td>
              <td className="is-clickable">
                <label class="checkbox" style={{ width: "100%", textAlign: "center" }}>
                  <input type="checkbox" checked={x.Selected} onClick={(e) => props.handlerCheckChange(i, x)}/>
                </label>
              </td>
            </tr>
          )}
        </tbody>
      </table>
    </div>
  );
}
