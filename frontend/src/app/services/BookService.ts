import { inject, Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { Observable } from "rxjs";
import { Book, CreateBook } from "./book";

export const apiUrl = "http://localhost:5105/api";

@Injectable({
  providedIn: "root",
})
export class BookService {
  private http = inject(HttpClient);

  getAll(): Observable<Book[]> {
    return this.http.get<Book[]>(`${apiUrl}/books`);
  }

  createBook(newBook: CreateBook) {
    return this.http.post<CreateBook>(`${apiUrl}/books/new`, newBook);
  }
}
