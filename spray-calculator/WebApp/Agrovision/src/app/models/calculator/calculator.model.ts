import { FieldModel } from '../field/field.model';

export class CalculatorModel {

    constructor(fieldKey: string, description: string,fieldSize: number , water: number, agent: number) {
        this.fieldKey = fieldKey;
        this.description = description;
        this.fieldSize = fieldSize;
        this.water = water;
        this.agent = agent;

    }
    fieldKey: string;
    description: string;
    fieldSize: number;
    water: number;
    agent: number;
}
