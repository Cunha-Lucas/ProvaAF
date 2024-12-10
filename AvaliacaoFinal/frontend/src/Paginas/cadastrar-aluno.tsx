import React, { useState } from "react";
import { useNavigate } from "react-router-dom";
import { Aluno } from "../Models/Aluno";

function CadastrarAlunos() {
  const navigate = useNavigate();
  const [nome, setNome] = useState("");
  const [sobrenome, setSobrenome] = useState("");

  function cadastrarAluno(e: any) {
    const aluno: Aluno = {
      nome: nome,
      sobrenome: sobrenome
    };

    fetch("http://localhost:5083/alunos/cadastrar", {
      method: "POST",
      headers: {
        "Content-Type": "application/json",
      },
      body: JSON.stringify(aluno),
    })
      .then((resposta) => resposta.json())
      .then((aluno: Aluno) => {
        navigate("/pages/aluno/listar");
      });
    e.preventDefault();
  }

  return (
    <div>
      <h1>Cadastrar Alunos</h1>
      <form onSubmit={cadastrarAluno}>
        <label>Nome:</label>
        <input
          type="text"
          placeholder="Digite o nome"
          onChange={(e: any) => setNome(e.target.value)}
          required
        />
        <br />
        <label>Sobrenome:</label>
        <input
          type="text"
          placeholder="Digite o sobrenome"
          onChange={(e: any) => setSobrenome(e.target.value)}
        />
        <br />
        <button type="submit">Cadastrar</button>
      </form>
    </div>
  );
}

export default CadastrarAlunos;
