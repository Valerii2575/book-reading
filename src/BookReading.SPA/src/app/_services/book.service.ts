import {Injectable} from '@angular/core';
import {HttpClient} from '@angular/common/http';

import {Book} from '../_models/Book';
import {Observable} from 'rxjs';
import { environment } from 'src/environments/environment';

@Injectable({
    providedIn : 'root'
})

export class BookService{
    private baseUrl: string = environment.baseUrl + 'api/';

    constructor(private http: HttpClient){}

    public addBook(book: Book){
        return this.http.post(this.baseUrl + 'books', book);
    }

    public updateBook(id: string, book: Book){
        return this.http.put(this.baseUrl + 'books/' + id, book);
    }

    public getBooks(): Observable<Book[]>{
        return this.http.get<Book[]>(this.baseUrl + 'books');
    }

    public getBookById(id:string): Observable<Book>{
        return this.http.get<Book>(this.baseUrl + 'books/' + id);
    }

    public deleteBook(id:string){
        return this.http.delete(this.baseUrl + 'books/' + id);
    }

    public searchBookWithCategory(searchedValue: string) : Observable<Book[]>{
        return this.http.get<Book[]>(this.baseUrl + 'books/earch-book-category/' + searchedValue);
    }
}