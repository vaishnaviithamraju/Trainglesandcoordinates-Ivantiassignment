import { Coordinate } from './Coordinate';

export class ResultSet {
    result: Coordinate[] = [];
    id: number = 0;
    exception: string = "";
    status: number = 0;
    isCanceled: boolean = false;
    isCompleted: boolean = false;
    // isCompletedSuccessfully: boolean = true;
    // creationOptions: number = 0;
    // asyncState: string ;
    // isFaulted: boolean

}