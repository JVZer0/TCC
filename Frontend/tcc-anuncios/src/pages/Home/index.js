import React, { useState, useEffect } from "react";
import { Link } from "react-router-dom";

import '../../components/Cabecalho/cabecalho.css'
import '../Home/style.css';

import Logo from '../../assets/image/Capturar.PNG'

import { ToastContainer, toast } from "react-toastify";
import 'react-toastify/dist/ReactToastify.css';

import anuncioAPI from '../../services/anuncioAPI';
const api = new anuncioAPI();


export default function Home(props){
    const [infos, setInfos] = useState(props.location.state);
    const [estado, setEstado] = useState('');
    const [cidade, setCidade] = useState('');
    const [genero, setGenero] = useState('');
    const [condicao, setCondicao] = useState('');
    const [barraPesquisa, setBarraPesquisa] = useState('');
    const [anuncios, setAnuncios] = useState([]);

    const consultarAnuncios = async () => {
        try{
            let e = "";
            let ci = "";
            let cond = "";
            let barra = "";
            let g = "";
            if(barraPesquisa == "") {barra = "BarraPesquisa"} else {barra = barraPesquisa};
            if(estado == "") {e = "Estado"} else {e = estado};
            if(cidade == "") {ci = "Cidade"} else {ci = cidade};
            if(genero == "") {g = "Genero"} else {g = genero};
            if(condicao == "") {cond = "Condicao"} else {cond = condicao};
            const resp = await api.consultarAnuncios(barra,e,ci,g,cond);
            setAnuncios(resp);
            console.log(anuncios)
        }
        catch (e) {
            toast.error(e.response.data.mensagem)
        }
    }

    useEffect(() => {
        consultarAnuncios();
      }, [])

    return(
        <div className="matheus">
            <div className="cabecalho">
                <div>
                    <Link className="hihi" to="/" ><img class="logo" src={Logo} width="150" height="27px" alt=''/></Link>
                </div> 
                <div className="barraPesquisa">
                    <input className="koko2 form-control" type="text" placeholder="Pesquisa" value={barraPesquisa} onChange={(e) => setBarraPesquisa(e.target.value)}></input>
                    <button onClick={consultarAnuncios}>Consultar</button>
                </div>
                <div className="meio"> 
                    <Link class="hihi meio" to={{ pathname: "/MeuPerfil", state: infos }}>Meu perfil</Link>
                    <Link class="hihi meio" to={{ pathname: "/MeusAnuncios", state: infos}}>Meus Anuncios</Link>
                    <Link class="hihi meio" to={{pathname: "/MeusFavoritos", state: infos}}>Meus Favoritos</Link>
                </div>
                <div>
                    <Link  class="hihi" to="/Anunciar"><button class="botao">Anunciar</button></Link>
                </div>
            </div>


            <div className="pedroga">
                <div className="pedrin">

                    <div className="pedrox">
                        <label className="matiolas">Estado:</label>
                        <select className="keliki1 form-control" onChange={(e) => setEstado(e.target.value)}>
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
                            <option value="SP">São Paulo</option>
                            <option value="Sergipe">Sergipe</option>
                            <option value="Tocantins">Tocantins</option>            
                        </select>
                    </div>

                    <div className="pedrox">
                        <label className="matiolas">Cidade:</label>
                        <input className="koko1 form-control" type="text" onChange={(e) => setCidade(e.target.value)} placeholder="Cidade"></input>
                    </div>

                    <div className="pedrox">
                        <label className="matiolas">Gênero:</label>
                        <select className="keliki3 form-control" onChange={(e) => setGenero(e.target.value)}>
                            <option value="">Gênero</option>
                            <option value="Masculino">Masculino</option>
                            <option value="Feminino">Feminino</option>
                            <option value="Unisex">Unissex</option>
                        </select>
                    </div>

                    <div className="pedrox">
                        <label className="matiolas">Condição:</label>
                        <select className="keliki4 form-control" onChange={(e) => setCondicao(e.target.value)}>
                            <option value="">Condição</option>
                            <option value="Novo">Novo</option>
                            <option value="Usado">Usado</option>
                        </select>
                    </div>
                </div>
                {anuncios.map(x =>
                    <div className="flow">
                        <div className="quadradin"> 
                            <div className="ima">
                                <img src={x.imagens.map(y => api.consultarImagem(y.textoImagem))}></img>
                            </div>

                            <div className="alin">
                                <h4>Titulo:{x.titulo}</h4>
                                <h6>Preço:{x.preco}</h6>
                                <h6>Marca:{x.marca}</h6>
                                <h6>Tamanho:{x.tamanho}</h6>
                                <h6>Condição:{x.condicao}</h6>
                                <h6>Genero:{x.genero}</h6>
                            </div>
                        </div> 
                    </div>
                )}

            </div>
            
            <div className="rodape">
                <div className="tey">
                    <h4>Site criado pelo time TK Soluções de Informática. Todos os direitos reservados</h4>
                </div>
            </div>
        </div>
    )
}