
export interface IResultDataList<TEntity> {
  entities: TEntity[];
  count: number;
  message?: string;
}
// export interface IResultDataList {
//     entities: {
//         id:never;
//         title:string;
//         author?:string;
//         genre?:string;
//         publishedYear?:number;
//       }[];
//       count: number;
//       message:string|null;
// }


