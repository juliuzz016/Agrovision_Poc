export class FieldModel {

    constructor(description: string, fieldSize: number) {
        this.description = description;
        this.fieldSize = fieldSize;
    }
    id: bigint;
    fieldKey: string;
    userKey: string;
    description: string;
    fieldSize: number;
    isActive: boolean;
}
