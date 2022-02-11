import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { TrianglesComponent } from './triangles.component';
import { NgbNavModule } from '@ng-bootstrap/ng-bootstrap';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule } from '@angular/forms';

@NgModule({
  declarations: [
    TrianglesComponent
  ],
  imports: [
    CommonModule,
    NgbNavModule,
    HttpClientModule,
    FormsModule
  ],
  exports: [
    TrianglesComponent
  ]
})
export class TrianglesModule { }
