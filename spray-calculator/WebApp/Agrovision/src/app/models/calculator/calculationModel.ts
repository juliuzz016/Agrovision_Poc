export class calculationRequestModel {

    constructor(agenVolume: number, fieldSize: number, waterRate: number) {
        this.agenVolume = agenVolume;
        this.fieldSize = fieldSize;
        this.waterRate = waterRate;
    }
    agenVolume: number;
    fieldSize: number;
    waterRate: number;
}