import logo from './logo.svg';
import './App.css';
import DataDisplay from './components/dataDisplay';
import InputForm from './components/inputForm';

function App() {
  return (
    <div className="App">
      <InputForm />
      <DataDisplay />
    </div>
  );
}

export default App;
