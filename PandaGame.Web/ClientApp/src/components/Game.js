import React, { Component } from "react";
import styled from "styled-components";
import { Hexagon } from "./Hexagon";
import { IrrigationChannel } from "./IrrigationChannel";

const GameBoard = styled.svg`
  width: 99vw;
  height: 99vh;
`;

export class Game extends Component {
  render() {
    return <GameBoard viewBox="-400 -400 800 800" preserveAspectRatio="xMidYMid meet">
      <IrrigationChannel q={1} r={0}/>
      <IrrigationChannel q={1} r={-1}/>
      <IrrigationChannel q={0} r={-1}/>
      <IrrigationChannel q={0} r={1}/>
      <IrrigationChannel q={-1} r={1}/>
      <IrrigationChannel q={-1} r={0}/>
      <Hexagon q={0} r={0}/>
    </GameBoard>
  }
}