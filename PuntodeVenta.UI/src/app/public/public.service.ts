import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, catchError, throwError } from 'rxjs';

@Injectable()
export class PublicService {
  constructor(private http: HttpClient) {}

  getProducts(): Observable<any> {
    return this.http.get('/api/Products').pipe(catchError(this.handleError));
  }

  getInventory(): Observable<any> {
    return this.http.get('/api/Inventory').pipe(catchError(this.handleError));
  }

  getSales(): Observable<any> {
    return this.http.get('/api/Sale').pipe(catchError(this.handleError));
  }

  getPartialClosure(): Observable<any> {
    return this.http
      .get('/api/CreatePartialClosure')
      .pipe(catchError(this.handleError));
  }

  getTotalClosure(): Observable<any> {
    return this.http
      .get('/api/CreateTotalClosure')
      .pipe(catchError(this.handleError));
  }

  createInventory(data: any): Observable<any> {
    return this.http
      .post('/api/Inventory', data)
      .pipe(catchError(this.handleError));
  }

  createProduct(data: any): Observable<any> {
    return this.http
      .post('/api/Product', data)
      .pipe(catchError(this.handleError));
  }

  createSale(data: any): Observable<any> {
    return this.http.post('/api/Sale', data).pipe(catchError(this.handleError));
  }

  updateSale(data: any): Observable<any> {
    return this.http.put('/api/Sale', data).pipe(catchError(this.handleError));
  }

  deleteSale(data: any): Observable<any> {
    return this.http
      .delete('/api/Sale', data)
      .pipe(catchError(this.handleError));
  }

  updateInventory(data: any): Observable<any> {
    return this.http
      .put('/api/Inventory', data)
      .pipe(catchError(this.handleError));
  }

  updateProduct(data: any): Observable<any> {
    return this.http
      .put('/api/Product', data)
      .pipe(catchError(this.handleError));
  }

  deleteProduct(data: any): Observable<any> {
    return this.http
      .delete('/api/Product', data)
      .pipe(catchError(this.handleError));
  }

  deleteInventory(data: any): Observable<any> {
    return this.http
      .delete('/api/Inventory', data)
      .pipe(catchError(this.handleError));
  }

  verifyLogin(data: any): Observable<any> {
    return this.http
      .post('/api/Auth/login', data)
      .pipe(catchError(this.handleError));
  }

  private handleError(error: HttpErrorResponse) {
    const msg = error.error;
    return throwError(msg);
  }
}
