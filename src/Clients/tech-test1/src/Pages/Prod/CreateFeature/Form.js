import React from "react";

export function Form(props) {
  return (
    <div>
      <div className="app-row columns">
        <div className="column">

          <div className="field">
            <label className="label is-small">Código Caracteristica</label>
            <div className="control">
              <input className="input is-small" type="text" placeholder="Código Caracteristica" disabled />
            </div>
          </div>

          <div className="field">
            <label className="label is-small">Nombre Caracteristica</label>
            <div className="control">
              <input className="input is-small" type="text" maxLength="100" placeholder="Nombre Caracteristica" />
            </div>
          </div>

          <div className="field">
            <label className="label is-small">Código Caracteristica</label>
            <div className="control">
              <div className="select is-small is-fullwidth">
                <select>
                  <option>Habilitado</option>
                  <option>Deshabilitado</option>
                </select>
              </div>
            </div>
          </div>

        </div>

        
        <div className="column"></div>
        <div className="column"></div>
      </div>
      <div className="app-control buttons">
        <button className="button is-info is-small">Normal</button>
        <button className="button is-small">Nuevo Registro</button>
      </div>
    </div>
  );
}