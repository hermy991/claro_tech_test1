import React from "react";

export function TableDetail(props) {
  return (
    <div className="table-container">
      <table className="table is-bordered is-striped is-narrow is-hoverable is-fullwidth">
        <thead>
          <tr className="has-background-info">
            <th className="has-text-info-light"><abbr title="Código Característica">Código</abbr></th>
            <th className="has-text-info-light"><abbr title="Nombre Característica">Nombre Característica</abbr></th>
            <th className="has-text-info-light"><abbr title="Nombre Característica">Valor</abbr></th>
          </tr>
        </thead>
        <tbody > {
          (props.details || []).map((x , i) => 
            <tr >
              <th>{x.FeatureCode}</th>
              <td>{x.FeatureDisplay}</td>
              <td className="is-clickable">
                {/* <label class="checkbox" style={{ width: "100%", textAlign: "center" }}>
                  <input type="checkbox" checked={x.Selected} onClick={(e) => props.handlerSelectChange(i, x)}/>
                </label> */}
                <div className="control">
                  <div className="select is-small is-fullwidth">
                    <select name="FeatureDetail_ID" value={x.FeatureDetail_ID} onChange={(e) => props.handlerSelectChange(i, x, e)}>
                      <option value={null}>~ Seleccionar ~</option>
                      { 
                        props.featureDetails
                          .filter(s => s.Feature_ID === x.Feature_ID)
                          .map(s => <option value={s.FeatureDetail_ID}>{s.FeatureDetailDisplay}</option>)
                      }
                    </select>
                  </div>
                </div>
              </td>
            </tr>
          )}
        </tbody>
      </table>
    </div>
  );
}
