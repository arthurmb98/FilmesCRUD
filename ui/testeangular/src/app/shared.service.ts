import { Injectable } from '@angular/core';
import {HttpClient} from '@angular/common/http';
import {Observable} from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class SharedService {
readonly APIUrl = "https://localhost:5001";

  constructor(private http:HttpClient) {}

  getGeneros():Observable<any[]>{
    return this.http.get<any>(this.APIUrl + '/teste/generos');
  }

  getFilmes():Observable<any[]>{
    return this.http.get<any>(this.APIUrl + '/teste/filmes');
  }

  postIncluirFilme(val:any){
    return this.http.post(this.APIUrl+'/teste/filmes',val);
  }

  putEditarFilme(val:any){
    return this.http.put(this.APIUrl+'/teste/filmes',val);
  }

  deleteFilme(val:any){
    return this.http.delete(this.APIUrl+'/teste/filmes/'+val);
  }


}
