import React, { useState, useEffect } from "react";
import { useHistory } from "react-router-dom";
import { Link } from "react-router-dom";

import '../../components/Cabecalho/cabecalho.css';
import '../Meu perfil/style.css';

import Logo from '../../assets/image/Capturar.PNG'

import { ToastContainer, toast } from "react-toastify";
import 'react-toastify/dist/ReactToastify.css';

import anuncioAPI from '../../services/anuncioAPI';
const api = new anuncioAPI();


export default function MeuPerfil(props){
    const navegacao = useHistory();

    const [infos, setInfos] = useState(props.location.state);

    console.log(infos);

    const alterarInfosUser = async () => {
        try {
            const modelo = await api.alterarInfosUsuario({
                IdUsuario: infos.idUsuario,
                Username: username,
                Senha: senha,
                NomeUsuario: nome,
                Email: email,
                DataDeNascimento: nascimento,
                Sexo: sexo,
                Celular: celular,
                Estado: estado,
                Cidade: cidade,
                CEP: cep,
                Bairro: bairro,
                N_Endereco: numero,
                Endereco: endereco,
                ComplementoEndereco: complemento
            });
            toast.success("Informações alteradas com sucesso")
        } catch (e) {
            toast.error(e.response.data.mensagem)
        }
    }

    const consultarInformacoesDoUsuario = async () => {
        try {
            const resp = await api.consultarUsuario(infos.idUsuario);
            console.log(resp)
            setNome(resp.data.nomeUsuario);
            setEmail(resp.data.email);
            setUsername(resp.data.username);
            setSenha(resp.data.senha);
            setNascimento(resp.data.dataDeNascimento.substring(0,10));
            setSexo(resp.data.sexo);
            setCelular(resp.data.celular);
            setEstado(resp.data.estado);
            setCidade(resp.data.cidade);
            setCep(resp.data.cep);
            setBairro(resp.data.bairro);
            setNumero(resp.data.n_Enderoco);
            setEndereco(resp.data.endereco);
            setComplemento(resp.data.complementoEndereco);
        } catch (e) {
            console.log(e.response)
        }
    };

    const voltar = () => {
        navegacao.push('/Home',infos)
    }

    useEffect(() => {
        consultarInformacoesDoUsuario();
      }, []);

    const [nome, setNome] = useState();
    const [email, setEmail] = useState();
    const [username, setUsername] = useState();
    const [senha, setSenha] = useState();
    const [nascimento, setNascimento] = useState();
    const [sexo, setSexo] = useState();
    const [celular, setCelular] = useState();
    const [estado, setEstado] = useState();
    const [cidade, setCidade] = useState();
    const [cep, setCep] = useState();
    const [bairro, setBairro] = useState();
    const [numero, setNumero] = useState();
    const [endereco, setEndereco] = useState();
    const [complemento, setComplemento] = useState();

    return(
        <div>
            <div className="cabecalho">
                <div>
                    <Link className="hihi" to={{ pathname: "/Home", state: infos }} ><img class="logo" src={Logo} width="150" height="27px" alt=''/></Link>
                </div>
                <div className="barraPesquisa"></div>
                <div className="meio"></div>
            </div>

            <div className=' d-flex justify-content-center align-items-center'>
                <div>
                    <div className="teco text-center">Meu Perfil</div>

                    <div className='form-group row d-flex justify-content-between align-items-center'>
                        <label className='col-sm-2 col-form-label'>Nome: </label>
                        <div className='col-sm-8'>
                            <input className="koko form-control" type="text" value={nome} onChange={(e) => setNome(e.target.value)}></input>
                        </div>
                    </div>

                    <div className='form-group row d-flex justify-content-between align-items-center'>
                        <label className='col-sm-2 col-form-label'>Email: </label>
                        <div className='col-sm-8'>
                            <input className="koko form-control" type="text" value={email} onChange={(e) => setEmail(e.target.value)}></input>
                        </div>
                    </div>

                    <div className='form-group row d-flex justify-content-between align-items-center'>
                        <label className='col-sm-2 col-form-label'>Username: </label>
                        <div className='col-sm-8'>
                            <input className="koko form-control" type="text" value={username} onChange={(e) => setUsername(e.target.value)}></input>
                        </div>
                    </div>

                    <div className='form-group row d-flex justify-content-between align-items-center'>
                        <label className='col-sm-2 col-form-label'>Senha: </label>
                        <div className='col-sm-8'>
                            <input className="koko form-control" type="text" value={senha} onChange={(e) => setSenha(e.target.value)}></input>
                        </div>
                    </div>

                    <div className='form-group row d-flex justify-content-between align-items-center'>
                        <label className='col-sm-2 col-form-label'>Data de Nascimento: </label>
                        <div className='col-sm-8'>
                            <input className="kaka form-control" type="date" value={nascimento} onChange={(e) => setNascimento(e.target.value)}></input>
                        </div>
                    </div>

                    <div className='form-group row d-flex justify-content-between align-items-center'>
                        <label className='col-sm-2 col-form-label'>Sexo: </label>
                        <div className='col-sm-8'>
                            <select className="kuku form-control" value={sexo} onChange={(e) => setSexo(e.target.value)}>
                                <option value="Masculino">Masculino</option>
                                <option value="Feminino">Feminino</option>
                                <option value="Não quero informar">Não quero informar</option>
                            </select>
                        </div>
                    </div>

                    <div className='form-group row d-flex justify-content-between align-items-center'>
                        <label className='col-sm-2 col-form-label'>Celular: </label>
                        <div className='col-sm-8'>
                            <input className="koko form-control" type="text" value={celular} onChange={(e) => setCelular(e.target.value)}></input>
                        </div>
                    </div>

                    <div className='form-group row d-flex justify-content-between align-items-center'>
                        <label className='col-sm-2 col-form-label'>Estado: </label>
                        <div className='col-sm-8'>
                            <select className="keliki form-control" value={estado} onChange={(e) => setEstado(e.target.value)}>
                                <option value="Selecione">Estado</option>
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
                                <option value="Tocantins">Tocantins</option>
                            </select>
                        </div>
                    </div>

                    <div className='form-group row d-flex justify-content-between align-items-center'>
                        <label className='col-sm-2 col-form-label'>Cidade: </label>
                        <div className='col-sm-8'>
                            <input className="koko form-control" type="text" value={cidade} onChange={(e) => setCidade(e.target.value)}></input>
                        </div>
                    </div>

                    <div className="ki">
                        <div className='form-group row d-flex justify-content-between align-items-center'>
                            <label className='col-sm-2 col-form-label'>CEP: </label>
                            <div className='col-sm-8'>
                                <input className="kruso form-control" type="text" value={cep} onChange={(e) => setCep(e.target.value)}></input>
                            </div>
                        </div>
                        <div className='form-group row d-flex justify-content-between align-items-center'>
                            <label className='col-sm-2 col-form-label'>Bairro: </label>
                            <div className='col-sm-8'>
                                <input className="kverna form-control" type="text" value={bairro} onChange={(e) => setBairro(e.target.value)}></input>
                            </div>
                        </div>
                        <div className='form-group row d-flex justify-content-between align-items-center'>
                            <label className='bolota col-sm-2 col-form-label'>Numero: </label>
                            <div className='col-sm-8'>
                                <input className="kdete form-control" type="number" value={numero} onChange={(e) => setNumero(e.target.value)}></input>
                            </div>
                        </div>
                    </div>

                    <div className='form-group row d-flex justify-content-between align-items-center'>
                        <label className='col-sm-2 col-form-label'>Endereço: </label>
                        <div className='col-sm-8'>
                            <input className="koko form-control" type="text" value={endereco} onChange={(e) => setEndereco(e.target.value)}></input>
                        </div>
                    </div>

                    <div className='form-group row d-flex justify-content-between align-items-center'>
                        <label className='col-sm-2 col-form-label'>Complemento: </label>
                        <div className='col-sm-8'>
                            <input className="koko form-control" type="text" value={complemento} onChange={(e) => setComplemento(e.target.value)}></input>
                        </div>
                    </div>

                    <div className="ct">
                        <button className='botox1' onClick={voltar}>Voltar</button>
                        <button className="botox2"  onClick={alterarInfosUser}>Salvar Alterações</button>
                    </div>

                </div>
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