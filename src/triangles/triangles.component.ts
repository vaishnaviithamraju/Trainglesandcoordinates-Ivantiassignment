import { Component, OnChanges, OnInit, SimpleChanges } from '@angular/core';
import { TriangleService } from './triangles.service';
import { Coordinate } from 'src/models/Coordinate';

@Component({
  selector: 'app-triangles',
  templateUrl: './triangles.component.html',
  styleUrls: ['./triangles.component.css'],
  providers: [TriangleService]
})
export class TrianglesComponent implements OnInit, OnChanges {
  triangleName: string;
  coordinateValues: Coordinate[];
  errorMessage: string;
  vertex1: string = "";
  vertex2: any = "";
  vertex3: any = "";
  wrongCoordinates: string = "";
  triangleNameFromOutput: string = "";

  constructor(private triangleservice: TriangleService) {
    this.triangleName = "";
    this.coordinateValues = [];
    this.errorMessage = "";
  }


  ngOnInit(): void {
    console.log(this.coordinateValues);
  }
  ngOnChanges(changes: SimpleChanges): void {
    console.log(this.coordinateValues);
  }

  getCoordinates() {
    this.triangleservice.getTriangleCoordinates(this.triangleName).subscribe(
      {
        next: (res: Coordinate[]) => { this.coordinateValues = res; this.errorMessage = "" },
        error: (err) => { this.errorMessage = err; this.coordinateValues = [] }
      });
  }

  getTriangleName() {
    let coordinates: Coordinate[] = [];
    try {
      let v1 = this.vertex1.split(",");
      let v2 = this.vertex2.split(",");
      let v3 = this.vertex3.split(",");
      if (v1.length != 2 || v2.length != 2 || v3.length != 2) {
        throw Error("Please enter proper coordinates");
      }
      coordinates.push(new Coordinate(parseInt(v1[0]), parseInt(v1[1])));
      coordinates.push(new Coordinate(parseInt(v2[0]), parseInt(v2[1])));
      coordinates.push(new Coordinate(parseInt(v3[0]), parseInt(v3[1])));
      this.triangleservice.getTriangleName(coordinates).subscribe(
        {
          next: (res: string) => { this.triangleNameFromOutput = res; this.errorMessage = "" },
          error: (err) => { this.wrongCoordinates = err; this.triangleNameFromOutput = "" }
        });
    }
    catch {
      this.wrongCoordinates = "Please enter proper coordinates";
    }

  }



}
