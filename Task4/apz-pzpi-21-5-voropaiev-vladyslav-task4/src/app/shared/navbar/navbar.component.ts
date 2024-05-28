import { Component } from '@angular/core';
import { AuthService } from '../../core/services/auth.service';

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.sass']
})
export class NavbarComponent {

  isAuthenticated = false;
  name = '';

  constructor(private authService: AuthService) { }

  ngOnInit() {
    this.isAuthenticated = this.authService.isAuthenticated();
    this.name = localStorage.getItem('userName') as string;
  }

  logout() {
    this.authService.logout();
  }
}
