import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { IRegister } from '../model/iregister';

@Injectable({
  providedIn: 'root'
})
export class MasterService {


  
  
   httpOption={
    headers:new HttpHeaders({
      'content-type':'application/json',
      'accept':'application/json'
    })}
  constructor(private http:HttpClient) { }
  usrGetList:string="https://localhost:7236/api/Register/GetDataList";
  urlAddNew:string="https://localhost:7236/api/Register/AddData";
  urlGetTeacher:string="https://localhost:7236/api/Teacher/GetTeacher";
  urlUpdate:string="https://localhost:7236/api/Register/UpdateData";
  urlDelete:string="https://localhost:7236/api/Register/DeleteData?id="

  getStudents(): Observable<any>
  {
    return this.http.get(this.usrGetList);
  }
  getTeacher():Observable<any>
  {
    return this.http.get(this.urlGetTeacher);
  }
  updateData(rest:IRegister)
  {
    
    return this.http.post<IRegister>(this.urlUpdate,rest,this.httpOption)
  }
  deleteData(id:number){
    return this.http.delete(this.urlDelete+id)
  }

  postDate(rest:IRegister):Observable<any>
  {
     
    return this.http.post(this.urlAddNew,rest,this.httpOption)
  }

  getStudentById(id:number):Observable<IRegister>
  {

    return this.http.get<IRegister>("https://localhost:7236/api/Register/GetStudentById?id="+id);
  }

  


}
