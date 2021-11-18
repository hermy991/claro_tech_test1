import React from "react"
import { Link } from "react-router-dom"

function TabHeader({title, active, icon, handlerClick}){
  let handlerActiveClick = (e) => {
    handlerClick({title, e});
  }
  return (
   <li className={ active? "is-active": "" }>
     <Link to="#" onClick={handlerActiveClick}>
       <span className="icon is-small"><i className={icon} aria-hidden="true"></i></span>
       <span>{title}</span>
     </Link>
   </li>
  )
}

export function TabContainer({active, children}){
  return (<div className={ active ? "" : "is-hidden"}>{ children }</div>)
}

export function Tabs(props){
  // console.log("typeof props.children", typeof props.children)
  let childrens = Array.isArray(props.children) ? props.children : typeof props.children === "object" ? [props.children] : [];
  // console.log("childrens", childrens)
  return (
    <>
    <div className="tabs">
    <ul>
      { childrens.map((x, i) => <TabHeader key={i.toString()} { ...props } { ...x.props }/> ) }
    </ul>
    </div>
    <div className="tabs-content">{ childrens.map((x, i) => <TabContainer active={x.props.active} key={i}> { x } </TabContainer> ) } </div>
  </>
    )
}