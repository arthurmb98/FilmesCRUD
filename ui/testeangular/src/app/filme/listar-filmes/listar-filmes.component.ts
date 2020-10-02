import { Component, OnInit, SimpleChanges } from '@angular/core';
import {SharedService} from 'src/app/shared.service';
import { IncluirFilmeComponent } from '../incluir-filme/incluir-filme.component';

@Component({
  selector: 'app-listar-filmes',
  templateUrl: './listar-filmes.component.html',
  styleUrls: ['./listar-filmes.component.css']
})
export class ListarFilmesComponent implements OnInit {

  constructor(private service:SharedService) {

  }

  ListaFilmes:any=[];
  ListaGeneros:any=[];
  inputsDesabilitados = true;

  pageSize = 4;
  page = 1;
  totalPage = 10;

  ModalTitle:string;
  ActivateAddEditFilme:boolean=false;
  filme:any;

  FilmeGeneroFilter:string="";
  FilmeNomeFilter:string="";
  FilmeListSemFiltro:any=[];

  ngOnInit(): void {
    this.refreshFilmeList();
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
    this.inputsDesabilitados = false;
  }

  editClick(item){
    this.filme=item;
    this.ModalTitle="Editar";
    this.ActivateAddEditFilme=true;
    this.inputsDesabilitados = false;
  }

  consultClick(item){
    this.filme=item;
    this.ModalTitle="Consultar";
    this.ActivateAddEditFilme=true;
    this.inputsDesabilitados = true;
  }

  deleteClick(item){
    if(confirm('Você realmente deseja deletar este item?')){
      this.service.deleteFilme(item.id).subscribe(data=>{
        alert("Sucesso!");
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
      this.totalPage = 10 * Math.max(this.ListaFilmes.length / this.pageSize);
    });
    this.service.getGeneros().subscribe(data=>{
      this.ListaGeneros=data;
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
