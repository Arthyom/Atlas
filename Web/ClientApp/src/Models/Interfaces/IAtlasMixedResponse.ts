export default interface IAtlasMixedResponse <TValue> {

    mainResource?: TValue;

    mainResourceCollection: TValue[];

    extras?: any;

}