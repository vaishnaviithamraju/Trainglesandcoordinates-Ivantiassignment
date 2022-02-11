import { Injectable } from '@angular/core';
import { HttpClient, HttpErrorResponse, HttpHeaders, HttpParams, HttpResponse } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { catchError, map } from 'rxjs/operators';
import { Coordinate } from 'src/models/Coordinate';
import { ResultSet } from 'src/models/ResultSet';

@Injectable()
export class TriangleService {

    results: Coordinate[] = [];
    url = "https://localhost:44329/Triangles/";
    constructor(private http: HttpClient
    ) { }

    getTriangleCoordinates(name: string): Observable<Coordinate[]> {
        return this.http.get<ResultSet>(this.url + name)
            .pipe(
                map(data => {
                    return data.result;
                }),
                catchError(this.handleError));
    }

    getTriangleName(coordinates: Coordinate[]): Observable<string> {
        const parameters = new HttpParams().append('inputcoordinates', JSON.stringify(coordinates));
        let options: Object = {
            params: parameters,
            responseType: 'text'
        }
        return this.http.get(this.url + "GetTriangleName", options)
            .pipe(
                map(data => {
                    return data as string;
                }),
                catchError(this.handleError));
    }

    private handleError(error: HttpErrorResponse) {
        return throwError(() => new Error(`Backend returned code ${error.status}, error was  ${error.error}`));
    }

}