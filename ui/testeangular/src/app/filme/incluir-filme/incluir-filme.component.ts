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
  @Output() onClose = new EventEmitter<any>();
  @Input() filme:any;
  ListaGeneros:any=[];
  id:number;
  titulo:string;
  diretor:string;
  generoId:number;
  sinopse:string;
  ano:number;

  ngOnInit(): void {
    this.id=this.filme.id;
    this.titulo=this.filme.titulo;
    this.diretor=this.filme.diretor;
    this.generoId=this.filme.generoId;
    this.sinopse=this.filme.sinopse;
    this.ano=this.filme.ano;

    this.service.getGeneros().subscribe(data=>{
      this.ListaGeneros=data;
    });

  }

  addFilme(){
    var val = {
      titulo:this.titulo,
      diretor:this.diretor,
      generoId:this.generoId,
      sinopse:this.sinopse,
      ano:this.ano};
    this.service.postIncluirFilme(val).subscribe(res=>{
      alert("Inserido com sucesso!");
      this.onClose.emit('');
      this.closemodal.nativeElement.click();
    });
  }

  updateFilme(){
    var val = {id:this.id,
      titulo:this.titulo,
      diretor:this.diretor,
      generoId:this.generoId,
      sinopse:this.sinopse,
      ano:this.ano};
    this.service.putEditarFilme(val).subscribe(res=>{
      alert("Editado com sucesso!");
      this.onClose.emit('');
      this.closemodal.nativeElement.click();
    });

  }
}
