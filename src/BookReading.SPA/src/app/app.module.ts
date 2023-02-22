import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { BrowserAnimationsModule} from '@angular/platform-browser/animations';
import {HttpClientModule} from '@angular/common/http';
//import { ToastrModule } from 'ngx-toastr';

import { FormsModule } from '@angular/forms';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';

import { BookService } from './_services/book.service';
import { CategoryService } from './_services/category.service';
//import { ConfirmationDialogService } from './_services/confirmation-dialog.service';
import { CategoryComponent } from './Categories/category/category.component';
import { CategoryListComponent } from './Categories/category-list/category-list.component';
import { BookComponent } from './Books/book/book.component';
import { BookListComponent } from './Books/book-list/book-list.component';
import { HomeComponent } from './home/home.component';
import { NavComponent } from './nav/nav.component';
import { ConfirmationDialogComponent } from './confirmation-dialog/confirmation-dialog.component';


@NgModule({
  declarations: [
    AppComponent,
    CategoryComponent,
    CategoryListComponent,
    BookComponent,
    BookListComponent,
    HomeComponent,
    NavComponent,
    ConfirmationDialogComponent
  ],
  imports: [
    BrowserModule,
    BrowserAnimationsModule,
    AppRoutingModule,
    //ToastrModule,
    HttpClientModule,
    FormsModule
  ],
  providers: [
    BookService,
    CategoryService,
    //ConfirmationDialogService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
