import React from "react";
import { TableDetail } from "./TableDetail";

export function Form(props) {
  return (
    <div>
      <div className="app-row columns">
        <div className="column is-two-fifths">

          <div className="field">
            <label className="label is-small">Código Característica</label>
            <div className="control">
              <input name="FeatureCode" className="input is-small" type="text" placeholder="Código Característica" disabled value={isNaN(props.form.FeatureCode) ? props.form.FeatureCode : props.form.FeatureCode.toString().padStart(4, '0') }/>
            </div>
          </div>

          <div className="field">
            <label className="label is-small">Nombre Característica</label>
            <div className="control">
              <input name="FeatureDisplay" className="input is-small" type="text" maxLength="100" placeholder="Nombre Característica" value={props.form.FeatureDisplay} onChange={props.handlerChange} />
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

        
        <div className="column">
          <div className="columns">
            <div className="field column">
              <label className="label is-small">Valor Característica</label>
              <div className="control ">
                <input name="FeatureDetailDisplay" className="input is-small" type="text" maxLength="100" placeholder="Valor Característica" value={props.formDetail.FeatureDetailDisplay} onChange={props.handlerDetailChange} />
                
                <div className="app-right-input-button">
                  <button className="button is-info is-small"
                          // onKeyUp={(e) => e.charCode === 13 ? props.handlerDetailButtons("+", props.detailIndex, props.formDetail) : undefined } 
                          onClick={() => props.handlerDetailButtons("+", props.detailIndex, props.formDetail)}>
                    <span className="icon is-small">
                      <i className="fa fa-plus"></i>
                    </span>
                  </button>
                  <button className="button is-danger is-small" onClick={() => props.handlerDetailButtons("-", props.detailIndex, props.formDetail)}>
                    <span className="icon is-small">
                      <i className="fa fa-minus"></i>
                    </span>
                  </button>
                  <button className="button is-small" onClick={() => props.handlerDetailButtons("/", props.detailIndex, props.formDetail)}>
                    <span className="icon is-small">
                      <i className="fa fa-eraser"></i>
                    </span>
                  </button>
                </div>
              </div>
            </div>
            
          </div>
          <TableDetail details={props.details} handlerSelectDetail={props.handlerSelectDetail}></TableDetail>
        </div>
      </div>
      <div className="app-control buttons">
        <button className="button is-info is-small" onClick={props.handlerSave}>Normal</button>
        <button className="button is-small" onClick={props.handlerNew}>Nuevo Registro</button>
      </div>
    </div>
  );
}