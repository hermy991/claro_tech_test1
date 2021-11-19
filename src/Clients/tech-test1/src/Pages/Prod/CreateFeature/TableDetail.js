import React from "react";

export function TableDetail(props) {
  return (
    <div className="table-container">
      <table className="table is-bordered is-striped is-narrow is-hoverable is-fullwidth">
        <thead>
          <tr className="has-background-info">
            <th className="has-text-info-light"><abbr title="Código Característica">Código Valor</abbr></th>
            <th className="has-text-info-light"><abbr title="Nombre Característica">Valor Característica</abbr></th>
          </tr>
        </thead>
        <tbody className="is-clickable"> {
          (props.details || []).map((x , i) => 
            <tr onClick={() => props.handlerSelectDetail(i)}>
              <th>{x.FeatureDetail_ID}</th>
              <td>{x.FeatureDetailDisplay}</td>
            </tr>
          )}
        </tbody>
      </table>
    </div>
  );
}
