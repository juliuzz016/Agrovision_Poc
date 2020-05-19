export class SprayModel {

    constructor(description: string, sparyerVolumeL: number) {
        this.description = description;
        this.sparyerVolumeL = sparyerVolumeL;

    }
    id: bigint;
    sprayerKey: string;
    description: string;
    sparyerVolumeL: number;
    isActive: boolean;
}
