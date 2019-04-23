import { TestBed, inject } from '@angular/core/testing';

import { AuthorizedUserService } from './authorized-user.service';

describe('AuthorizedUserService', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [AuthorizedUserService]
    });
  });

  it('should be created', inject([AuthorizedUserService], (service: AuthorizedUserService) => {
    expect(service).toBeTruthy();
  }));
});
