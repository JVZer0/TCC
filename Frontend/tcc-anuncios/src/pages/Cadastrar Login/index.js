import React, { useState } from "react";
import { useHistory } from "react-router-dom";
import { Link } from "react-router-dom";

import '../../components/Cabecalho/cabecalho.css';
import '../Cadastrar Login/style.css';

import Logo from '../../assets/image/Capturar.PNG'

import { ToastContainer, toast } from "react-toastify";
import 'react-toastify/dist/ReactToastify.css';

import InputMask from 'react-input-mask';

import AnuncioAPI from '../../services/anuncioAPI'
const api = new AnuncioAPI();


export default function CadastrarLogin(){
    const navegacao = useHistory();

    const [nome, setNome] = useState('');
    const [email, setEmail] = useState('');
    const [username, setUsername] = useState('');
    const [senha, setSenha] = useState('');
    const [confirmar, setConfirmar] = useState('');
    const [nascimento, setNascimento] = useState();
    const [sexo, setSexo] = useState('');
    const [cpf, setCpf] = useState('');
    const [rg, setRg] = useState('');
    const [celular, setCelular] = useState('');
    const [estado, setEstado] = useState('');
    const [cidade, setCidade] = useState('');
    const [cep, setCep] = useState('');
    const [bairro, setBairro] = useState('');
    const [numero, setNumero] = useState('');
    const [endereco, setEndereco] = useState('');
    const [complemento, setComplemento] = useState('');
    const [concordo, setConcordo] = useState(false);

    const salvarClick = async() => {
        try {
            let rgMask = `${rg.substring(0,2)}.${rg.substring(2,5)}.${rg.substring(5,8)}-${rg.substring(8,10)}`;

            const modelo = {
                NomeUsuario: nome,
                Email: email,
                Username: username,
                Senha: senha,
                ConfirmarSenha: confirmar,
                DataDeNascimento: nascimento,
                Sexo: sexo,
                CPF: cpf,
                RG: rgMask,
                Celular: celular,
                Estado: estado,
                Cidade: cidade,
                CEP: cep,
                Bairro: bairro,
                N_Endereco: numero,
                Endereco: endereco,
                ComplementoEndereco: complemento,
                ConcordoTermos: concordo
            };
            const resp = await
            api.cadastrar(modelo);
            navegacao.push("/Login");
        } catch (e) {
            toast.error(e.response.data.mensagem)
        }
    }

    return(
        <div>
            <div className="cabecalho">
                <div>
                    <Link className="hihi" to="/" ><img class="logo" src={Logo} width="180" height="34px"/></Link>
                </div>
                <div className="barraPesquisa"></div>
                <div className="meio"></div>
            </div>

            <div className="ku">

                <div className="teco">Cadastrar</div>

                <div className="a">
                    <label  className="b1">Nome</label>
                    <input className="koko" type="text" value={nome} onChange={e => setNome(e.target.value)} placeholder="Nome Completo"></input>
                </div>

                <div className="a">
                    <label  className="b1">Email</label>
                    <input className="koko" type="text" value={email} onChange={e => setEmail(e.target.value)} placeholder="Email"></input>
                </div>

                <div className="a">
                    <label  className="b1">Username</label>
                    <input className="koko" type="text" value={username} onChange={e => setUsername(e.target.value)} placeholder="Username"></input>
                </div>

                <div className="a">
                    <label  className="b1">Senha</label>
                    <input className="koko" type="password" value={senha} onChange={e => setSenha(e.target.value)} placeholder="Senha"></input>
                </div>

                <div className="a">
                    <label  className="b1">Confirmar senha</label>
                    <input className="koko" type="password" value={confirmar} onChange={e => setConfirmar(e.target.value)} placeholder="Confirmar senha"></input>
                </div>

                <div className="a">
                    <label  className="b13">Data de Nascimento</label>
                    <input className="kaka" type="date" value={nascimento} onChange={e => setNascimento(e.target.value)}></input>
                </div>

                <div className="a">
                    <label  className="b1">Gênero</label>
                    <select className="kuku" value={sexo} onChange={e => setSexo(e.target.value)}>
                        <option value="">Gênero</option>
                        <option value="Masculino">Masculino</option>
                        <option value="Feminino">Feminino</option>
                        <option value="Não Binário">Não Binário</option>
                    </select>
                </div>

                <div className="a">
                    <label  className="b1">CPF</label>
                    <InputMask className="koko" value={cpf} mask="999.999.999-99" onChange={e => setCpf(e.target.value)} placeholder="CPF"/>
                </div>

                <div className="a">
                    <label  className="b1">RG (Somente o número)</label>
                    <input className="koko" type="text" value={rg} onChange={e => setRg(e.target.value)} placeholder="RG"></input>
                </div>

                <div className="a">
                    <label  className="b1">Número de celular com DDD</label>
                    <InputMask className="koko" value={celular} mask="(99) 99999-9999" onChange={e => setCelular(e.target.value)} placeholder="Número de celular"/>
                </div>

                <div className="a">
                    <label  className="b1">Estado</label>
                    <select className="keliki" onChange={e => setEstado(e.target.value)}>
                        <option value="">Estado</option>
                        <option value="Acre">Acre</option>
                        <option value="Alagoas">Alagoas</option>
                        <option value="Amapá">Amapá</option>
                        <option value="Amazonas">Amazonas</option>
                        <option value="Bahia">Bahia</option>
                        <option value="Ceará">Ceará</option>
                        <option value="Distrito Federal">Distrito Federal</option>
                        <option value="Espírito Santo">Espírito Santo</option>
                        <option value="Goiás">Goiás</option>
                        <option value="Maranhão">Maranhão</option>
                        <option value="Mato Grosso">Mato Grosso</option>
                        <option value="Mato Grosso do Sul">Mato Grosso do Sul</option>
                        <option value="Minas Gerais">Minas Gerais</option>
                        <option value="Pará">Pará</option>
                        <option value="Paraíba">Paraíba</option>
                        <option value="Paraná">Paraná</option>
                        <option value="Pernambuco">Pernambuco</option>
                        <option value="Piauí">Piauí</option>
                        <option value="Rio de Janeiro">Rio de Janeiro</option>
                        <option value="Rio Grande do Norte">Rio Grande do Norte</option>
                        <option value="Rio Grande do Sul">Rio Grande do Sul</option>
                        <option value="Rondônia">Rondônia</option>
                        <option value="Roraima">Roraima</option>
                        <option value="Santa Catarina">Santa Catarina</option>
                        <option value="São Paulo">São Paulo</option>
                        <option value="Sergipe">Sergipe</option>
                        <option value="Tocantins ">Tocantins</option>
                    </select>
                </div>

                <div className="a">
                    <label  className="b1">Cidade</label>
                    <input className="koko" type="text" value={cidade} onChange={e => setCidade(e.target.value)} placeholder="Cidade"></input>
                </div>

                <div className="ki1">

                    <div className="a">
                        <label  className="b13">CEP</label>
                        <InputMask className="kruso1" value={cep} mask="99999-999" onChange={e => setCep(e.target.value)} placeholder="CEP"/>
                    </div>
                    
                    <div className="a">
                        <label  className="b14">Bairro</label> 
                        <input className="kverna2" type="text" value={bairro} onChange={e => setBairro(e.target.value)} placeholder="Bairro"></input>
                    </div>
                    
                    <div className="a">
                        <label  className="b13">Número</label> 
                        <input className="kdete3" type="text" value={numero} onChange={e => setNumero(e.target.value)} placeholder="N°"></input>
                    </div>    

                </div>

                <div className="a">
                    <label  className="b12">Endereço</label>
                    <input className="koko" type="text" value={endereco} onChange={e => setEndereco(e.target.value)} placeholder="Endereço"></input>
                </div>
                
                <div className="a">
                    <label  className="b12">Complemento</label>
                    <input className="koko" type="text" value={complemento} onChange={e => setComplemento(e.target.value)} placeholder="Complemento"></input>
                </div>

                <div className="ka">
                    <input className="ktia" type="checkbox" value={concordo} onChange={e => setConcordo(e.target.checked ? true : false)}></input>
                    <h5>Li e concordo com os termos de uso</h5>
                </div>

                <button onClick={salvarClick} className="botox">Cadastrar</button>

            </div>

            <div className="rodape">
                <div className="tey">
                    <h5>Site criado pelo time TK Soluções de Informática. Todos os direitos reservados</h5>
                </div>
            </div>
            <ToastContainer/>
        </div>
    )
}