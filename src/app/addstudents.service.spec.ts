import { TestBed } from '@angular/core/testing';

import { AddstudentsService } from './addstudents.service';

describe('AddstudentsService', () => {
  let service: AddstudentsService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(AddstudentsService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
