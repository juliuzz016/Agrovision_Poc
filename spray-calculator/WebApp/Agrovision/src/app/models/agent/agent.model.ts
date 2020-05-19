export class AgentModel {
    /**
     *
     */
    constructor(AgentDescription: string, recomendedDosage: number ) {
        this.agentDescription = AgentDescription;
        this.recomendedDosage = recomendedDosage;
    }
    id: bigint;
    agentKey: string;
    agentDescription: string;
    recomendedDosage: number;

}
