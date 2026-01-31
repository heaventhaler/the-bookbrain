import { inject, Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { Observable } from "rxjs";
import { Book } from "./book";

export const apiUrl = "http://localhost:5105/api";

@Injectable({
  providedIn: "root",
})
export class BookService {
  private apiUrl = `${apiUrl}/books`;
  private http = inject(HttpClient);

  getAll(): Observable<Book[]> {
    return this.http.get<Book[]>(this.apiUrl);
  }
}
