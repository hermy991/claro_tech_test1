export function toPascal(data){
  let letterChanger = (str) => {
    if(!str)
      return str;
    return str.substr(0, 1).toUpperCase() + str.substr(1, str.lenght);
  };
  let tdatas = [];
  if(Array.isArray(data)){
    for(let o of data){
      let tdata = {};
      for(let key in o){
        console.log("key", key, "letterChanger(key)", letterChanger(key), "o[key]", o[key])
        tdata[letterChanger(key)] = o[key];
      }
      tdatas.push(tdata);
    }
    return tdatas;
  }
  else if(typeof data === "object"){
    let tdata = {};
    for(let key in data){
      tdata[letterChanger(key)] = data[key];
    }
    return tdata;
  }
  else return data;
}