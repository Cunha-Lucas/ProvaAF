import React from 'react';
import { BrowserRouter } from 'react-router-dom';
import CadastrarAlunos from './Paginas/cadastrar-aluno';
import ListarAlunoIMC from './Paginas/listar-alunoIMC'

function App() {
  return (
    <div>
      <BrowserRouter>
        <CadastrarAlunos />
        <ListarAlunoIMC />
      </BrowserRouter>
    </div>
  );
}

export default App;
