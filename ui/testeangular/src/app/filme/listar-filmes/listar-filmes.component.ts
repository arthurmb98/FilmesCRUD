import { Component, OnInit } from '@angular/core';
import {SharedService} from 'src/app/shared.service';

@Component({
  selector: 'app-listar-filmes',
  templateUrl: './listar-filmes.component.html',
  styleUrls: ['./listar-filmes.component.css']
})
export class ListarFilmesComponent implements OnInit {

  constructor(private service:SharedService) { this.refreshFilmeList(); }

  ListaFilmes:any=[];

  ModalTitle:string;
  ActivateAddEditFilme:boolean=false;
  filme:any;

  FilmeGeneroFilter:string="";
  FilmeNomeFilter:string="";
  FilmeListSemFiltro:any=[];

  ngOnInit(): void {
  }

  addClick(){
    this.filme={
      id:0,
      titulo:"",
      diretor:"",
      generoId:0
    }
    this.ModalTitle="Incluir";
    this.ActivateAddEditFilme=true;

  }

  editClick(item){
    this.filme=item;
    this.ModalTitle="Editar";
    this.ActivateAddEditFilme=true;
  }

  consultarClick(item){
    this.filme=item;
    this.ModalTitle="Consultar";
    this.ActivateAddEditFilme=false;
  }

  deleteClick(item){
    if(confirm('Você realmente deseja deletar este item?')){
      this.service.deleteFilme(item.id).subscribe(data=>{
        alert(data.toString());
        this.refreshFilmeList();
      })
    }
  }

  closeClick(){
    this.ActivateAddEditFilme=false;
    this.refreshFilmeList();
  }

  refreshFilmeList(){
    this.service.getFilmes().subscribe(data=>{
      this.ListaFilmes=data;
      this.FilmeListSemFiltro=data;
    });
  }

  FilterFn(){
    var FilmeGeneroFilter = this.FilmeGeneroFilter;
    var FilmeNomeFilter = this.FilmeNomeFilter;

    this.ListaFilmes = this.FilmeListSemFiltro.filter(function (el){
        return el.generoId.toString().toLowerCase().includes(
          FilmeGeneroFilter.toString().trim().toLowerCase()
        )&&
        el.titulo.toString().toLowerCase().includes(
          FilmeNomeFilter.toString().trim().toLowerCase()
        )
    });
  }

  sortResult(prop,asc){
    this.ListaFilmes = this.FilmeListSemFiltro.sort(function(a,b){
      if(asc){
          return (a[prop]>b[prop])?1 : ((a[prop]<b[prop]) ?-1 :0);
      }else{
        return (b[prop]>a[prop])?1 : ((b[prop]<a[prop]) ?-1 :0);
      }
    })
  }


}
