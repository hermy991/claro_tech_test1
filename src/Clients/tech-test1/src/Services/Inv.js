const pathBase = "api/v1/inv"
const options = { 
  method: 'POST', 
  headers: {
    'Content-Type': 'application/json'
  },
}

async function post(path, body){
  let toptions = JSON.parse(JSON.stringify(options));
  body = body || {};
  toptions.body = JSON.stringify(body);
  const r = await fetch(`${pathBase}${path}`, toptions);
  const json = await r.json();
  return json;
}

export async function getInventories(){
  const json = await post(`/entities/Inventory`, body);
  return json;
}

export async function getInventoryStatus(){
  const json = await post(`/entities/InventoryStatus`, body);
  return json;
}

export async function getWarehouse(){
  const json = await post(`/entities/Warehouses`, body);
  return json;
}