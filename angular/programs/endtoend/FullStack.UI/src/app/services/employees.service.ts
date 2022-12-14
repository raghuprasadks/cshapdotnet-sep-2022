import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Employee } from '../models/employee.model';

@Injectable({
  providedIn: 'root'
})
export class EmployeesService {

  baseApiUrl:string=environment.baseApiUrl;
  constructor(private http : HttpClient) { }
  
  getAllEmployees():Observable<Employee[]>{
    return this.http.get<Employee[]>(this.baseApiUrl+'/api/employees');
  }
  addEmployee(addEmployeeRequest:Employee):Observable<Employee>{
    addEmployeeRequest.id='30dd879c-ee2f-11db-8314-0800200c9a66';
    return this.http.post<Employee>(this.baseApiUrl+'/api/employees',addEmployeeRequest);
  }
}
