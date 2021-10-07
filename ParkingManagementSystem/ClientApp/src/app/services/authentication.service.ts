import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable } from 'rxjs';
import { Register, User } from '../models/user.model';
@Injectable({ providedIn: 'root' })
export class AuthenticationService {
  private _currentUserSubject$: BehaviorSubject<User>;
  public currentUser$: Observable<User>;
  public isLogin = this.isCookieExist();

  

  constructor(private http: HttpClient) {
    this._currentUserSubject$ = new BehaviorSubject<User>(JSON.parse(localStorage.getItem('currentUser')));
    this.currentUser$ = this._currentUserSubject$.asObservable();
  }

  public get currentUserValue(): User {
    return this._currentUserSubject$.value;
  }
  updateCurrentUser() {
    this.http.get('https://localhost:44394/api/Account/GetCurrentUser').subscribe((res: any) => {
      this._currentUserSubject$.next(res);
    });
  }
  login(username: string, password: string) {
    return this.http.post<any>(`https://localhost:44394/api/Account/Login`, { username, password },
      { observe: 'response', withCredentials: true })
      .subscribe((data: any) => {
        if (data) {
          // if (data.body && data.body.isUserAuth) {
            
          //   this.hubsService.GetUserList();
          //   this.hubsService._hubConnecton.invoke("UpdateConnectionId",username);
            
          //   this.isLogin = true;
          // }
          this._currentUserSubject$.next(data.body);
        }
      }, err => {

      })
  }
  register(registerDetails: Register) {

    return this.http.post<any>(`https://localhost:44394/api/Account/Register`, registerDetails,
      { observe: 'response', withCredentials: true })
      .subscribe((data: any) => {
        if (data) {
          // if (data.body && data.body.isUserAuth) {
          //   this.hubsService.GetUserList();
          //   this.hubsService._hubConnecton.invoke("UpdateConnectionId",registerDetails.userName);

          //   this.isLogin = true;
          // }
         this._currentUserSubject$.next(data.body);
        }
      }, err => {

      })
  }

  logout() {

    // return this.http.post("https://localhost:44394/api/Account/Logout", null).subscribe((removedUserName: any) => {
    //   if (removedUserName) {
    //     this.hubsService._hubConnecton.invoke("RemoveConnectionId",removedUserName.toString());

    //     this.isLogin = false;
    //   }
    //   this._currentUserSubject$.next(null);
    // }, err => {

    // })


    this.http.post<any>("https://localhost:44394/api/Account/Logout", null,
                        { observe: 'response', withCredentials: true })
     .subscribe((logout: any) => {
      // if (logout.body && !logout.body.error) {
      //   let removedUserName = logout.body.userName;
      //   this.hubsService._hubConnecton.invoke("RemoveConnectionId",removedUserName);
      //   this.isLogin = this.isCookieExist();
      // }
      this._currentUserSubject$.next(null);

    }, err => {

    })
  }


  // remove user from local storage to log user out
  //localStorage.removeItem('currentUser');
  isCookieExist() {
    var myCookie = this.getCookie("AppCookie");

    if (myCookie === null) {
      return false
    }
    else {
      return true;
    }
  }
  getCookie(name) {
    var dc = document.cookie;
    var prefix = name + "=";
    var begin = dc.indexOf("; " + prefix);
    if (begin === -1) {
      begin = dc.indexOf(prefix);
      if (begin != 0) return null;
    }
    else {
      begin += 2;
      var end = document.cookie.indexOf(";", begin);
      if (end === -1) {
        end = dc.length;
      }
    }
    // because unescape has been deprecated, replaced with decodeURI
    //return unescape(dc.substring(begin + prefix.length, end));
    return decodeURI(dc.substring(begin + prefix.length, end));
  }
}
