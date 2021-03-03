import { HttpClientTestingModule } from '@angular/common/http/testing';
import { TestBed } from '@angular/core/testing';

import { LoanService } from './loan.service';

describe('LoanService', () => {
    let service: LoanService;

    beforeEach(() => {
        TestBed.configureTestingModule({
            imports: [HttpClientTestingModule],
        });
        service = TestBed.inject(LoanService);
    });

    it('should be created', () => {
        expect(service).toBeTruthy();
    });
});
