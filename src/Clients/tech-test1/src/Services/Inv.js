const pathBase = "api/v1/inv"
const options = { 
  method: 'POST', 
  headers: {
    'Content-Type': 'application/json'
  },
}

export async function getInventories(){
  let toptions = JSON.parse(JSON.stringify(options));
  if(body){
    toptions.body = JSON.stringify(body);
  }
  const r = await fetch(`${pathBase}/entities/Inventory`, toptions);
  const json = await r.json();
  return json;
}

export async function getInventoryStatus(){
  let toptions = JSON.parse(JSON.stringify(options));
  if(body){
    toptions.body = JSON.stringify(body);
  }
  const r = await fetch(`${pathBase}/entities/InventoryStatus`, toptions);
  const json = await r.json();
  return json;
}

export async function getWarehouse(){
  let toptions = JSON.parse(JSON.stringify(options));
  if(body){
    toptions.body = JSON.stringify(body);
  }
  const r = await fetch(`${pathBase}/entities/Warehouses`, toptions);
  const json = await r.json();
  return json;
}