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

    const consultarInformacoesDoUsuario = async () => {
        try {
            const resp = await api.consultarUsuario(infos.idUsuario);
            console.log(resp)
            setNome(resp.data.nomeUsuario);
            setEmail(resp.data.email);
            setUsername(resp.data.username);
            setSenha(resp.data.senha);
            setNascimento(resp.data.dataDeNascimento.substring(0,10));
            setGenero(resp.data.genero);
            setCelular(resp.data.celular);
            setEstado(resp.data);
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

    useEffect(() => {
        consultarInformacoesDoUsuario();
      }, []);

    const [nome, setNome] = useState();
    const [email, setEmail] = useState();
    const [username, setUsername] = useState();
    const [senha, setSenha] = useState();
    const [nascimento, setNascimento] = useState();
    const [genero, setGenero] = useState();
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
                        <label className='col-sm-2 col-form-label'>Gênero: </label>
                        <div className='col-sm-8'>
                            <select className="kuku form-control" value={genero} onChange={(e) => setGenero(e.target.value)}>
                                <option value="Selecione">Gênero</option>
                                <option value="Selecione">Masculino</option>
                                <option value="Selecione">Feminino</option>
                                <option value="Selecione">Não Binário</option>
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
                                <option value="Selecione">Acre</option>
                                <option value="Selecione">Alagoas</option>
                                <option value="Selecione">Amapá</option>
                                <option value="Selecione">Amazonas</option>
                                <option value="Selecione">Bahia</option>
                                <option value="Selecione">Ceará</option>
                                <option value="Selecione">Distrito Federal</option>
                                <option value="Selecione">Espírito Santo</option>
                                <option value="Selecione">Goiás</option>
                                <option value="Selecione">Maranhão</option>
                                <option value="Selecione">Mato Grosso</option>
                                <option value="Selecione">Mato Grosso do Sul</option>
                                <option value="Selecione">Minas Gerais</option>
                                <option value="Selecione">Pará</option>
                                <option value="Selecione">Paraíba</option>
                                <option value="Selecione">Paraná</option>
                                <option value="Selecione">Pernambuco</option>
                                <option value="Selecione">Piauí</option>
                                <option value="Selecione">Rio de Janeiro</option>
                                <option value="Selecione">Rio Grande do Norte</option>
                                <option value="Selecione">Rio Grande do Sul</option>
                                <option value="Selecione">Rondônia</option>
                                <option value="Selecione">Roraima</option>
                                <option value="Selecione">Santa Catarina</option>
                                <option value="Selecione">São Paulo</option>
                                <option value="Selecione">Sergipe</option>
                                <option value="Selecione">Tocantins</option>
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
                            <label className='col-sm-2 col-form-label'>Numero: </label>
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
                        <button className="botox1">Cancelar</button>
                        <button className="botox2">Salvar Alterações</button>
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