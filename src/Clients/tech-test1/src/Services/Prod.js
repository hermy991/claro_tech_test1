import * as glob from "./Glob";

const pathBase = "api/v1/prod"
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

export async function getFeatures(body){
  const json = await post(`/entities/Feature`, body);
  return json;
}

export async function getFeatureDetails(body){
  const json = await post(`/entities/FeatureDetail`, body);
  if(json.data){
    json.data = glob.toPascal(json.data);
  }
  return json;
}

export async function getMerchandises(body){
  const json = await post(`/entities/Merchandise`, body);
  return json;
}

export async function getMerchandiseFeatures(body){
  const json = await post(`/entities/MerchandiseFeature`, body);
  return json;
}

export async function getProducts(body){
  const json = await post(`/entities/Product`, body);
  return json;
}

export async function getProductFeatures(body){
  const json = await post(`/entities/ProductFeature`, body);
  return json;
}

export async function fgetProducts(body){
  const json = await post(`/functions/getProducts`, body);
  if(json.data){
    json.data = glob.toPascal(json.data);
  }
  return json;
}

export async function fgetProductFeatures(body){
  const json = await post(`/functions/getProductFeatures`, body);
  if(json.data){
    json.data = glob.toPascal(json.data);
  }
  return json;
}

export async function fgetFeatureDetails(body){
  if(body.Feature_ID && !Array.isArray(body.Feature_ID)){
    body.Feature_ID = [body.Feature_ID];
  }
  const json = await post(`/functions/getFeatureDetails`, body);
  return json;
}

export async function saveFeature(body){
  const json = await post(`/process/saveFeature`, body);
  return json;
}

export async function saveMerchandise(body){
  const json = await post(`/process/saveMerchandise`, body);
  return json;
}

export async function saveProduct(body){
  const json = await post(`/process/saveProduct`, body);
  return json;
}