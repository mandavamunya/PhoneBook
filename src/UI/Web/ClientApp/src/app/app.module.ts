import { platformBrowserDynamic } from '@angular/platform-browser-dynamic';
import { CommonModule } from '@angular/common';
import { HttpClientModule, HttpClient} from '@angular/common/http';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';
import { RouterModule, Routes } from '@angular/router';

//import { BrowserModule } from '@angular/platform-browser';
//import { NgModule } from '@angular/core';
//import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MatIconModule, MatCardModule, MatFormFieldModule, MatInputModule, MatButtonModule, MatSnackBarModule, MatToolbarModule, MatGridListModule } from '@angular/material';

import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

import { EntryService } from './services/entry.service';
import { PhoneBookService } from './services/phone-book.service';

import { PhoneBooksComponent } from './phone-book/phone-books.component';
import { HomeComponent } from './home/home.component';
import { PhoneBookComponent } from './phone-book/phone-book.component';
import { NewEntryComponent } from './entry/new-entry.component';
import { NewPhoneBookComponent } from './phone-book/new-phone-book.component';
import { EditEntryComponent } from './entry/edit-entry.component';
import { EditPhoneBookComponent } from './phone-book/edit-phone-book.component';


const routes = [{
    path: '',
    component: HomeComponent
  },
  {
    path: 'phonebooks',
    component: PhoneBooksComponent
  },
  {
    path: 'phonebooks/:id',
    component: PhoneBooksComponent
  },
  {
    path: 'phonebook',
    component: PhoneBookComponent
  },
  {
    path: 'addphonebook',
    component: NewPhoneBookComponent
  },  
  {
    path: 'phonebook/:id',
    component: PhoneBookComponent
  },
  {
    path: 'edit-entry/:id',
    component: EditEntryComponent
  },
  {
    path: 'edit-phonebook/:id',
    component: EditPhoneBookComponent
  }
];


@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    NewEntryComponent,
    EditEntryComponent,
    EditPhoneBookComponent,
    NewPhoneBookComponent,
    PhoneBookComponent,
    PhoneBooksComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    BrowserModule,
    BrowserAnimationsModule,
    HttpModule,
    CommonModule,
    RouterModule.forRoot(routes),
    FormsModule,
    ReactiveFormsModule,
    MatIconModule, MatCardModule, MatFormFieldModule, MatInputModule, MatButtonModule, MatSnackBarModule, MatToolbarModule, MatGridListModule
  ],
  providers: [    
    HttpClientModule,
    EntryService,
    PhoneBookService,
    { provide: 'BASE_URL', useFactory: getBaseUrl }],
  bootstrap: [AppComponent]
})
export class AppModule { }

export function getBaseUrl() {
  return document.getElementsByTagName('base')[0].href;
}
