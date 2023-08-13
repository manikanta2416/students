import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import{Observable} from 'rxjs'
import { Router,Route } from '@angular/router';
@Injectable({
  providedIn: 'root'
})
export class AddstudentsService {
  
  // private student?: Student;
   constructor(private _http: HttpClient) {}
  //  setStudent(studentfromadd :Student) {
  //   this.student = studentfromadd;}
    
  //   getstudent():any{
  //       return this.student
  //   }
  url="http://localhost:3000/Register";
  users(){     
    return this._http.get(this.url);
  }

     
}
// addStudent(studentData: any): Observable<any> {
// return this.http.post<any>(`${this.apiUrl}/students`, studentData);
// }
// addstudent(data:any){
//   console.log(data);
//   return this._http.post(this.url,data) ;
// }


