import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
//import { Http, Headers } from '@angular/http';
import { Observable } from 'rxjs';
import { Http, Headers, RequestOptions } from '@angular/http';
import { Config } from './config';

const httpOptions = {
  headers: new HttpHeaders({
    'Content-Type':  'application/json',
    'Access-Control-Allow-Origin': '*'
    //'Authorization': 'my-auth-token'
  })
};

export interface Item {
name: string;
description: string;
url: string;
html: string;
markdown: string;
}

@Injectable({
providedIn: 'root'
})

export class ApiService {

options:any;
private  dataURL: string = "http://localhost:8050/values/4820";
private  dataURLSave: string = "http://ws-in913:8050/values/Save/4820";
//private  dataURL: string = "https://www.techiediaries.com/api/data.json";
httpHeadersTest={
    headers: new HttpHeaders({
        'Content-Type': 'application/json'
    })
}
private  dataURLSaveDummy: string = "http://ws-in913:8050/values/savedummy";

constructor(public httpClient: HttpClient, public http: Http) {
	let headers = new Headers();
    headers.append('ZUMO-API-VERSION', '2.0.0');
    headers.append('Content-Type','application/json');
    headers.append('Access-Control-Allow-Origin','*');
    this.options = new RequestOptions({ headers: headers });
}

fetch(): Observable<any> {
return this.http.get("/values/4820");

}

fetchDates(){
return this.httpClient.get(Config.service + 'values/4820');

}



fetchWeekRange(data: string): Observable<any> {
return this.httpClient.get(this.dataURL+"/"+data);
}


postDates(data: any): Observable<any>{
let httpOptions = {
  headers: new HttpHeaders({
    'Content-Type':  'application/json',
    //'Access-Control-Allow-Origin': '*',
    'Accept': 'application/json'
    //'Authorization': 'my-auth-token'
  })
};
	let jsonData = JSON.stringify(data);
	return this.httpClient.post(this.dataURLSave,jsonData,httpOptions);
}


postDatesDummy(): Observable<any>  {

let data = {
  "text": "Name",
  "id": "5"
};
	const body = JSON.stringify(data);
	return this.httpClient.post<any>('http://localhost:8050/values/savedummy',this.options)
}

genericPost(): Observable<any> {
let data = {
  "text": "Name",
  "id": "5"
};
let body = JSON.stringify(data);
return this.http.post(Config.service + "/values/savedummy", body, this.options);
  }

}
