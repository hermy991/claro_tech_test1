import React from "react";

export function Form(props) {
  return (
    <div>
      <div className="app-row columns">
        <div className="column">

          <div className="field">
            <label className="label is-small">Código Caracteristica</label>
            <div className="control">
              <input name="FeatureCode" className="input is-small" type="text" placeholder="Código Caracteristica" disabled value={isNaN(props.form.FeatureCode) ? props.form.FeatureCode : props.form.FeatureCode.toString().padStart(4, '0') }/>
            </div>
          </div>

          <div className="field">
            <label className="label is-small">Nombre Caracteristica</label>
            <div className="control">
              <input name="FeatureDisplay" className="input is-small" type="text" maxLength="100" placeholder="Nombre Caracteristica" value={props.form.FeatureDisplay} onChange={props.handlerChange} />
            </div>
          </div>

          <div className="field">
            <label className="label is-small">Estatus</label>
            <div className="control">
              <div className="select is-small is-fullwidth">
                <select name="Active" value={props.form.Active} onChange={props.handlerChange}>
                  <option value={true}>Habilitado</option>
                  <option value={false}>Deshabilitado</option>
                </select>
              </div>
            </div>
          </div>

        </div>

        
        <div className="column"></div>
        <div className="column"></div>
      </div>
      <div className="app-control buttons">
        <button className="button is-info is-small" onClick={props.handlerSave}>Normal</button>
        <button className="button is-small" onClick={props.handlerNew}>Nuevo Registro</button>
      </div>
    </div>
  );
}