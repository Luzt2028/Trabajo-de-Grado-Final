import {
  XYPlot,
  XAxis,
  YAxis,
  HorizontalGridLines,
  LineMarkSeries,
  MarkSeries,
  Hint,
} from "react-vis";
import "./App.css";

function App() {
  const urlsearchParams = new URLSearchParams(window.location.search);
  const xa = Math.round(Number(urlsearchParams.get("xa")) * 1000) / 1000;
  const ya = Math.round(Number(urlsearchParams.get("ya")) * 1000) / 1000;
  const aName = urlsearchParams.get("aName");
  const xb = Math.round(Number(urlsearchParams.get("xb")) * 1000) / 1000;
  const yb = Math.round(Number(urlsearchParams.get("yb")) * 1000) / 1000;
  const bName = urlsearchParams.get("bName");
  const xc = Math.round(Number(urlsearchParams.get("xc")) * 1000) / 1000;
  const yc = Math.round(Number(urlsearchParams.get("yc")) * 1000) / 1000;
  const cName = urlsearchParams.get("cName");
  const xd = Math.round(Number(urlsearchParams.get("xd")) * 1000) / 1000;
  const yd = Math.round(Number(urlsearchParams.get("yd")) * 1000) / 1000;
  const dName = urlsearchParams.get("dName");

  const myData = [
    { x: xa, y: ya, size: 10, color: "red" },
    { x: xb, y: yb, size: 10, color: "blue" },
    { x: xc, y: yc, size: 10, color: "green" },
    { x: xd, y: yd, size: 10, color: "purple" },
  ];

  return (
    <div>
      <h1>Gráfica resultado</h1>
      <XYPlot width={700} height={700} margin={100}>
        <HorizontalGridLines />
        <MarkSeries colorType="literal" data={myData} />
        <XAxis />
        <YAxis />
      </XYPlot>
      <div className="legend-container">
        <div className="legend" style={{ color: "red" }}>
          <div className="legend-title">-{aName}</div>
          <div className="legend-subtitle ">
            ({xa},{ya})
          </div>
        </div>
        <div className="legend" style={{ color: "blue" }}>
          <div className="legend-title">-{bName}</div>
          <div className="legend-subtitle ">
            ({xb},{yb})
          </div>
        </div>
        <div className="legend" style={{ color: "green" }}>
          <div className="legend-title">-{cName}</div>
          <div className="legend-subtitle ">
            ({xc},{yc})
          </div>
        </div>
        <div className="legend" style={{ color: "purple" }}>
          <div className="legend-title">-{dName}</div>
          <div className="legend-subtitle ">
            ({xd},{yd})
          </div>
        </div>
      </div>
    </div>
  );
}

export default App;
