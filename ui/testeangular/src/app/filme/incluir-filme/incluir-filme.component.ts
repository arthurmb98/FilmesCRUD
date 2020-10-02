import { Component, EventEmitter, Input, OnInit, Output, ViewChild} from '@angular/core';
import { SharedService } from 'src/app/shared.service';

@Component({
  selector: 'app-incluir-filme',
  templateUrl: './incluir-filme.component.html',
  styleUrls: ['./incluir-filme.component.css']
})
export class IncluirFilmeComponent implements OnInit {

  constructor(private service:SharedService) {

   }

  @ViewChild('closemodal') closemodal;
  @Output() Close = new EventEmitter<any>();
  @Input() filme:any;
  @Input() inputsDesabilitados:boolean;
  ListaGeneros:any=[];
  id:number;
  titulo:string;
  diretor:string;
  generoId:number;
  sinopse:string;
  ano:number;


   ngOnInit() {
    this.carregaGeneros();
    this.id=this.filme.id;
    this.titulo=this.filme.titulo;
    this.diretor=this.filme.diretor;
    this.generoId=this.filme.generoId;
    this.sinopse=this.filme.sinopse;
    this.ano=this.filme.ano;

  }

  carregaGeneros(){
    this.service.getGeneros().subscribe(data=>{
      this.ListaGeneros=data;
    });
  }

  addFilme(){
    if(this.titulo?.length > 0 && this.diretor?.length > 0 && this.generoId != 0){
    var val = {
      titulo:this.titulo,
      diretor:this.diretor,
      generoId:this.generoId,
      sinopse:this.sinopse,
      ano:this.ano};
    this.service.postIncluirFilme(val).subscribe(res=>{
      alert("Inserido com sucesso!");
      this.Close.emit('');
      this.closemodal.nativeElement.click();
    });
  }else{
    alert("Uma ou mais informações estão incorretas!");
    return;
  }
  }

  updateFilme(){
    if(this.titulo?.length > 0 && this.diretor?.length > 0 && this.generoId != 0){
      var val = {id:this.id,
        titulo:this.titulo,
        diretor:this.diretor,
        generoId:this.generoId,
        sinopse:this.sinopse,
        ano:this.ano};
      this.service.putEditarFilme(val).subscribe(res=>{
        alert("Editado com sucesso!");
        this.Close.emit('');
        this.closemodal.nativeElement.click();
      });
    }else{
      alert("Uma ou mais informações estão incorretas!");
      return;
    }


  }
}
