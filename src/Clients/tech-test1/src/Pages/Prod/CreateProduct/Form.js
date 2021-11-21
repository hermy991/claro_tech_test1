import React from "react";
import { TableDetail } from "./TableDetail"

export function Form(props) {

  let merchandise = props.merchandises.find(x => Number(x.Merchandise_ID) === Number(props.form.Merchandise_ID));
  // let tax = new Intl.NumberFormat(undefined, { maximumFractionDigits: 2 }).format(props.form.Tax);
  // let totalPrice = new Intl.NumberFormat(undefined, { maximumFractionDigits: 2 }).format(props.form.TotalPrice);
  // let tax = props.form.Tax;
  // let totalPrice = props.form.TotalPrice; 

  // console.log({ tax, totalPrice})

  return (
    <div>
      <div className="app-row columns">
        <div className="column is-two-fifths">

          <div className="field">
            <label className="label is-small">Mercancía</label>
            <div className="control">
              <div class="select is-small is-fullwidth">
                <select name="Merchandise_ID" value={props.form.Merchandise_ID} onChange={props.handlerChange}>
                  <option value={0}>~ Seleccionar ~</option>
                  {props.merchandises.map(x => <option value={x.Merchandise_ID}>{`${x.MerchandiseCode} - ${x.MerchandiseDisplay}`}</option>)}
                </select>
              </div>
            </div>
          </div>
          

          <div className="field">
            <label className="label is-small">Código Mercancía</label>
            <div className="control">
              <input name="MerchandiseCode" className="input is-small" type="text" placeholder="Código Mercancía" disabled value={merchandise ? merchandise.MerchandiseCode : "" } />
            </div>
          </div>

          <div className="field">
            <label className="label is-small">Código Producto</label>
            <div className="control">
              <input name="ProductCode" className="input is-small" type="text" maxLength="20" placeholder="Código Producto" value={props.form.ProductCode.toUpperCase() } onChange={props.handlerChange}/>
            </div>
          </div>

          <div className="field">
            <label className="label is-small">Nombre Producto</label>
            <div className="control">
              <input name="ProductDisplay" className="input is-small" type="text" maxLength="100" placeholder="Nombre Producto" value={props.form.ProductDisplay} onChange={props.handlerChange} />
            </div>
          </div>

          <div className="field">
            <label className="label is-small">Nombre Reducido</label>
            <div className="control">
              <input name="ProductShort" className="input is-small" type="text" maxLength="100" placeholder="Nombre Reducido" value={props.form.ProductShort} onChange={props.handlerChange} />
            </div>
          </div>

          <div className="field">
            <label className="label is-small">Impuesto</label>
            <div className="control">
              <input name="Tax" className="input is-small" type="text" placeholder="Impuesto" value={props.form.Tax} onChange={props.handlerChange} />
            </div>
          </div>

          <div className="field">
            <label className="label is-small">Precio Final</label>
            <div className="control">
              <input name="TotalPrice" className="input is-small" type="text" placeholder="Precio Final" value={props.form.TotalPrice} onChange={props.handlerChange} />
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
          <TableDetail details={props.details} featureDetails={props.featureDetails} handlerSelectChange={props.handlerSelectChange}></TableDetail>
        </div>
      </div>
      <div className="app-control buttons">
        <button className="button is-info is-small" onClick={props.handlerSave}>Normal</button>
        <button className="button is-small" onClick={props.handlerNew}>Nuevo Registro</button>
      </div>
    </div>
  );
}